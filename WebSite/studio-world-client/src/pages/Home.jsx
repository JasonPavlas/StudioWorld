import React from 'react';

const Home = () => {
  return (
    <div className="home-container">
      <section className="hero">
        <h1>Welcome to Studio World</h1>
        <p>A dynamic space dedicated to nurturing artistic talent</p>
      </section>
      
      <section className="services-overview">
        <h2>Our Services</h2>
        <div className="services-grid">
          <div className="service-card">
            <h3>Content Creation</h3>
            <p>Professional content creation services for all your needs</p>
          </div>
          <div className="service-card">
            <h3>Tattooing</h3>
            <p>Expert tattooing from experienced artists</p>
          </div>
          <div className="service-card">
            <h3>Barbershop</h3>
            <p>Premium haircuts and styling</p>
          </div>
          <div className="service-card">
            <h3>Cosmetology</h3>
            <p>Complete beauty and skincare services</p>
          </div>
          <div className="service-card">
            <h3>Massage Therapy</h3>
            <p>Relaxing and therapeutic massage services</p>
          </div>
        </div>
      </section>
      
      <section className="about-preview">
        <h2>About Studio World</h2>
        <p>
          Studio World is a Content Creation Plaza, designed to capture every aspect of a developing artist. 
          We dedicate one week each month to training programs for emerging artists — especially kids and teens — 
          helping them grow their skills early.
        </p>
        <button>Learn More</button>
      </section>
    </div>
  );
};

export default Home;
