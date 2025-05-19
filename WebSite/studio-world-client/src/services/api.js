// filepath: /Users/jason/_repos/StudioWorld/WebSite/studio-world-client/src/services/api.ts
import { Service, TrainingProgram, Booking, UpcomingTraining } from '../types/api';

const API_BASE_URL = 'http://localhost:5052/api';

// Error handler utility function
const handleError = (error: unknown, message: string): never => {
  console.error(`${message}:`, error);
  throw error instanceof Error ? error : new Error(message);
};

// Generic fetch function to reduce code duplication
async function fetchFromApi<T>(endpoint: string, options?: RequestInit): Promise<T> {
  try {
    const response = await fetch(`${API_BASE_URL}/${endpoint}`, options);
    if (!response.ok) {
      throw new Error(`API error: ${response.status} ${response.statusText}`);
    }
    return await response.json() as T;
  } catch (error) {
    return handleError(error, `Failed to fetch from ${endpoint}`);
  }
}

// Services API
export const fetchServices = (): Promise<Service[]> => {
  return fetchFromApi<Service[]>('services');
};

export const fetchServiceById = (id: number): Promise<Service> => {
  return fetchFromApi<Service>(`services/${id}`);
};

// Bookings API
export const submitBooking = (bookingData: Omit<Booking, 'id' | 'status'>): Promise<Booking> => {
  return fetchFromApi<Booking>('bookings', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(bookingData),
  });
};

// Training Programs API
export const fetchTrainingPrograms = (): Promise<TrainingProgram[]> => {
  return fetchFromApi<TrainingProgram[]>('trainingprograms');
};

export const fetchUpcomingTrainings = (): Promise<UpcomingTraining[]> => {
  return fetchFromApi<UpcomingTraining[]>('trainingprograms/upcoming');
};
