// Type definitions for Studio World API

export enum ServiceCategory {
  ContentCreation = 0,
  Tattooing = 1,
  Barbershop = 2,
  Cosmetology = 3,
  MassageTherapy = 4
}

export enum TrainingCategory {
  ContentCreation = 0,
  Tattooing = 1,
  Barbering = 2,
  Cosmetology = 3,
  MassageTherapy = 4
}

export enum BookingStatus {
  Pending = 0,
  Confirmed = 1,
  Cancelled = 2,
  Completed = 3
}

export interface Service {
  id: number;
  name: string;
  description: string;
  imageUrl: string;
  price: number;
  category: ServiceCategory;
  isAvailable: boolean;
}

export interface TrainingProgram {
  id: number;
  name: string;
  description: string;
  duration: string;
  ageGroups: string;
  price: number;
  category: TrainingCategory;
  isAvailable: boolean;
}

export interface Booking {
  id: number;
  customerName: string;
  customerEmail: string;
  customerPhone: string;
  serviceId: number;
  appointmentDateTime: string;
  notes: string;
  status: BookingStatus;
}

export interface UpcomingTraining {
  month: string;
  dates: string;
  registrationOpen: boolean;
}
