import { useState, useEffect } from 'react';
import { 
  fetchServices, 
  fetchTrainingPrograms, 
  fetchUpcomingTrainings 
} from '../services/api';
import { Service, TrainingProgram, UpcomingTraining } from '../types/api';
import { useAppContext } from '../context/AppContext';

export const useServices = () => {
  const { 
    services, 
    setServices, 
    isLoading, 
    setIsLoading, 
    error, 
    setError 
  } = useAppContext();

  useEffect(() => {
    const getServices = async () => {
      if (services.length > 0) return; // Don't fetch if we already have services

      setIsLoading(true);
      try {
        const data = await fetchServices();
        setServices(data);
        setError(null);
      } catch (err) {
        setError('Failed to load services. Please try again later.');
      } finally {
        setIsLoading(false);
      }
    };
    
    getServices();
  }, [services.length, setServices, setIsLoading, setError]);

  return { services, isLoading, error };
};

export const useTrainingPrograms = () => {
  const { 
    trainingPrograms, 
    setTrainingPrograms, 
    isLoading, 
    setIsLoading, 
    error, 
    setError 
  } = useAppContext();
  const [upcomingSchedule, setUpcomingSchedule] = useState<UpcomingTraining[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      if (trainingPrograms.length > 0) return; // Don't fetch if we already have training programs
      
      setIsLoading(true);
      try {
        const [programsData, scheduleData] = await Promise.all([
          fetchTrainingPrograms(),
          fetchUpcomingTrainings()
        ]);
        
        setTrainingPrograms(programsData);
        setUpcomingSchedule(scheduleData);
        setError(null);
      } catch (err) {
        setError('Failed to load training information. Please try again later.');
      } finally {
        setIsLoading(false);
      }
    };
    
    fetchData();
  }, [trainingPrograms.length, setTrainingPrograms, setIsLoading, setError]);

  return { trainingPrograms, upcomingSchedule, isLoading, error };
};

export const useServiceById = (id: number | null) => {
  const { services } = useAppContext();
  const [service, setService] = useState<Service | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;
    
    const findService = async () => {
      // First check if we have it already
      const existingService = services.find(s => s.id === id);
      if (existingService) {
        setService(existingService);
        return;
      }
      
      // If not, fetch it from the API
      setIsLoading(true);
      try {
        const data = await fetchServices();
        const foundService = data.find(s => s.id === id);
        if (foundService) {
          setService(foundService);
        } else {
          setError('Service not found');
        }
      } catch (err) {
        setError('Failed to load service details');
      } finally {
        setIsLoading(false);
      }
    };
    
    findService();
  }, [id, services]);

  return { service, isLoading, error };
};
