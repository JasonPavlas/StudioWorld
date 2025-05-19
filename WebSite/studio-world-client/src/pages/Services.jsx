import React, { useState, useEffect } from 'react';
import { fetchServices } from '../services/api';
import ServiceCard from '../components/ServiceCard';

const Services = () => {
  const [services, setServices] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  
  useEffect(() => {
    const getServices = async () => {
      try {
        const data = await fetchServices();
        setServices(data);
        setLoading(false);
      } catch (err) {
        setError('Failed to load services. Please try again later.');
        setLoading(false);
      }
    };
    
    getServices();
  }, []);
  
  // Group services by category
  const groupedServices = services.reduce((acc, service) => {
    const category = service.category;
    if (!acc[category]) {
      acc[category] = [];
    }
    acc[category].push(service);
    return acc;
  }, {});
  
  const getCategoryName = (categoryKey) => {
    const names = {
      0: 'Content Creation',
      1: 'Tattooing',
      2: 'Barbershop',
      3: 'Cosmetology',
      4: 'Massage Therapy'
    };
    return names[categoryKey] || 'Other Services';
  };

  return (
    <div className="services-container">
      <h1>Our Services</h1>
      
      {loading ? (
        <div className="loading">Loading services...</div>
      ) : error ? (
        <div className="error">{error}</div>
      ) : (
        <>
          {Object.keys(groupedServices).map((category) => (
            <section key={category} className="service-category">
              <h2>{getCategoryName(category)}</h2>
              <div className="services-grid">
                {groupedServices[category].map((service) => (
                  <ServiceCard
                    key={service.id}
                    title={service.name}
                    description={service.description}
                    imageUrl={service.imageUrl}
                  />
                ))}
              </div>
            </section>
          ))}
        </>
      )}
      
      <section className="booking">
        <h2>Book a Service</h2>
        <p>Ready to book? Contact us to schedule your appointment.</p>
        <button onClick={() => window.location.href = '/schedule'}>Schedule Now</button>
      </section>
    </div>
  );
};

export default Services;
