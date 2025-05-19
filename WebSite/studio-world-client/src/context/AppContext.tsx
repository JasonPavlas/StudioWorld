// src/context/AppContext.tsx
import React, { createContext, useContext, useState, ReactNode } from 'react';
import { Service, TrainingProgram } from '../types/api';

interface AppContextType {
  services: Service[];
  setServices: React.Dispatch<React.SetStateAction<Service[]>>;
  trainingPrograms: TrainingProgram[];
  setTrainingPrograms: React.Dispatch<React.SetStateAction<TrainingProgram[]>>;
  selectedService: Service | null;
  setSelectedService: React.Dispatch<React.SetStateAction<Service | null>>;
  isLoading: boolean;
  setIsLoading: React.Dispatch<React.SetStateAction<boolean>>;
  error: string | null;
  setError: React.Dispatch<React.SetStateAction<string | null>>;
}

const AppContext = createContext<AppContextType | undefined>(undefined);

export function useAppContext() {
  const context = useContext(AppContext);
  if (context === undefined) {
    throw new Error('useAppContext must be used within an AppProvider');
  }
  return context;
}

interface AppProviderProps {
  children: ReactNode;
}

export function AppProvider({ children }: AppProviderProps) {
  const [services, setServices] = useState<Service[]>([]);
  const [trainingPrograms, setTrainingPrograms] = useState<TrainingProgram[]>([]);
  const [selectedService, setSelectedService] = useState<Service | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  const value = {
    services,
    setServices,
    trainingPrograms,
    setTrainingPrograms,
    selectedService,
    setSelectedService,
    isLoading,
    setIsLoading,
    error,
    setError
  };

  return <AppContext.Provider value={value}>{children}</AppContext.Provider>;
}
