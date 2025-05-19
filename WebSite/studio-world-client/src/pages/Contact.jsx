import React from 'react';

const Contact = () => {
  return (
    <div className="contact-container">
      <h1>Contact Us</h1>
      
      <section className="contact-info">
        <h2>Get in Touch</h2>
        <p>
          Have questions about our services or training programs? We're here to help!
        </p>
        
        <div className="contact-details">
          <div className="contact-item">
            <h3>Address</h3>
            <p>123 Creative Avenue</p>
            <p>Artsville, ST 12345</p>
          </div>
          
          <div className="contact-item">
            <h3>Phone</h3>
            <p>(555) 123-4567</p>
          </div>
          
          <div className="contact-item">
            <h3>Email</h3>
            <p>info@studioworld.org</p>
          </div>
          
          <div className="contact-item">
            <h3>Hours</h3>
            <p><strong>Monday-Friday:</strong> 9:00 AM - 8:00 PM</p>
            <p><strong>Saturday:</strong> 10:00 AM - 6:00 PM</p>
            <p><strong>Sunday:</strong> 12:00 PM - 5:00 PM</p>
          </div>
        </div>
      </section>
      
      <section className="contact-form">
        <h2>Send Us a Message</h2>
        <form>
          <div className="form-group">
            <label htmlFor="name">Name</label>
            <input type="text" id="name" name="name" placeholder="Your Name" />
          </div>
          
          <div className="form-group">
            <label htmlFor="email">Email</label>
            <input type="email" id="email" name="email" placeholder="your.email@example.com" />
          </div>
          
          <div className="form-group">
            <label htmlFor="subject">Subject</label>
            <input type="text" id="subject" name="subject" placeholder="Message Subject" />
          </div>
          
          <div className="form-group">
            <label htmlFor="message">Message</label>
            <textarea id="message" name="message" placeholder="Type your message here..."></textarea>
          </div>
          
          <button type="submit">Send Message</button>
        </form>
      </section>
      
      <section className="map">
        <h2>Find Us</h2>
        <div className="map-container">
          {/* In a real implementation, this would be a Google Maps or other map embed */}
          <div className="map-placeholder">
            <p>Map will be displayed here</p>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Contact;
