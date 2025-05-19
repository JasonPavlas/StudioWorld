import React from 'react';

const Footer = () => {
  const year = new Date().getFullYear();
  
  return (
    <footer className="main-footer">
      <div className="footer-content">
        <div className="footer-section">
          <h3>Studio World</h3>
          <p>A dynamic space dedicated to nurturing artistic talent.</p>
        </div>
        
        <div className="footer-section">
          <h3>Quick Links</h3>
          <ul>
            <li><a href="/">Home</a></li>
            <li><a href="/services">Services</a></li>
            <li><a href="/about">About</a></li>
            <li><a href="/schedule">Schedule</a></li>
            <li><a href="/training">Training</a></li>
            <li><a href="/contact">Contact</a></li>
          </ul>
        </div>
        
        <div className="footer-section">
          <h3>Contact Us</h3>
          <p>123 Creative Avenue</p>
          <p>Artsville, ST 12345</p>
          <p>Phone: (555) 123-4567</p>
          <p>Email: info@studioworld.org</p>
        </div>
        
        <div className="footer-section">
          <h3>Follow Us</h3>
          <div className="social-links">
            <a href="#" className="social-link">Facebook</a>
            <a href="#" className="social-link">Instagram</a>
            <a href="#" className="social-link">Twitter</a>
            <a href="#" className="social-link">YouTube</a>
          </div>
        </div>
      </div>
      
      <div className="footer-bottom">
        <p>&copy; {year} Studio World. All rights reserved.</p>
      </div>
    </footer>
  );
};

export default Footer;
