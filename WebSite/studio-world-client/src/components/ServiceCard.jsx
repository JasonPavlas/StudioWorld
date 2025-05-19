import React from 'react';

const ServiceCard = ({ title, description, imageUrl }) => {
  return (
    <div className="service-card">
      {imageUrl && <img src={imageUrl} alt={title} className="service-image" />}
      <div className="service-content">
        <h3>{title}</h3>
        <p>{description}</p>
        <a href="#" className="service-link">Learn More</a>
      </div>
    </div>
  );
};

export default ServiceCard;
