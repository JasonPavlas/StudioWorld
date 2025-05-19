import React, { useState, useEffect } from 'react';
import { fetchTrainingPrograms, fetchUpcomingTrainings } from '../services/api';

const Training = () => {
  const [trainingPrograms, setTrainingPrograms] = useState([]);
  const [upcomingSchedule, setUpcomingSchedule] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  
  useEffect(() => {
    const fetchData = async () => {
      try {
        const [programsData, scheduleData] = await Promise.all([
          fetchTrainingPrograms(),
          fetchUpcomingTrainings()
        ]);
        
        setTrainingPrograms(programsData);
        setUpcomingSchedule(scheduleData);
        setLoading(false);
      } catch (err) {
        setError('Failed to load training information. Please try again later.');
        setLoading(false);
      }
    };
    
    fetchData();
  }, []);
  
  const getCategoryName = (categoryKey) => {
    const names = {
      0: 'Content Creation',
      1: 'Tattooing',
      2: 'Barbering',
      3: 'Cosmetology',
      4: 'Massage Therapy'
    };
    return names[categoryKey] || 'Other';
  };
  
  return (
    <div className="training-container">
      <h1>Training Programs</h1>
      
      <section className="training-intro">
        <h2>Develop Your Skills at Studio World</h2>
        <p>
          At Studio World, we dedicate one week each month to training programs for emerging artists — 
          especially kids and teens — helping them grow their skills early. Our programs are designed 
          to provide hands-on experience and mentorship from experienced professionals.
        </p>
      </section>
      
      {loading ? (
        <div className="loading">Loading training programs...</div>
      ) : error ? (
        <div className="error">{error}</div>
      ) : (
        <>
          <section className="training-programs">
            <h2>Our Programs</h2>
            
            {trainingPrograms.map(program => (
              <div className="program" key={program.id}>
                <h3>{program.name}</h3>
                <p>{program.description}</p>
                <div className="program-details">
                  <p><strong>Category:</strong> {getCategoryName(program.category)}</p>
                  <p><strong>Duration:</strong> {program.duration}</p>
                  <p><strong>Age Groups:</strong> {program.ageGroups}</p>
                  <p><strong>Price:</strong> ${program.price}</p>
                </div>
              </div>
            ))}
          </section>
          
          <section className="upcoming-schedule">
            <h2>Upcoming Training Weeks</h2>
            <ul>
              {upcomingSchedule.map((schedule, index) => (
                <li key={index}>
                  <strong>{schedule.month}:</strong> {schedule.dates}
                  {schedule.registrationOpen && <span className="registration-open"> (Registration Open)</span>}
                </li>
              ))}
            </ul>
            <p>Registration opens one month before each training week. Space is limited!</p>
            <button onClick={() => window.location.href = '/schedule'}>Register for Training</button>
          </section>
        </>
      )}
    </div>
  );
};

export default Training;
