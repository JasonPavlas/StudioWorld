import React from 'react';

const Layout = ({ children }) => {
  return (
    <div className="layout">
      <header className="header">
        <div className="logo">
          <h1>Studio World</h1>
        </div>
        <nav className="main-nav">
          <ul>
            <li><a href="/">Home</a></li>
            <li><a href="/services">Services</a></li>
            <li><a href="/about">About</a></li>
            <li><a href="/schedule">Schedule</a></li>
            <li><a href="/training">Training</a></li>
            <li><a href="/contact">Contact</a></li>
          </ul>
        </nav>
      </header>
      
      <main className="main-content">
        {children}
      </main>
      
      <footer className="footer">
        <div className="footer-content">
          <div className="footer-section">
            <h3>Studio World</h3>
            <p>A dynamic space dedicated to nurturing artistic talent.</p>
          </div>
          
          <div className="footer-section">
            <h3>Contact Us</h3>
            <p>123 Creative Avenue</p>
            <p>Artsville, ST 12345</p>
            <p>info@studioworld.org</p>
          </div>
          
          <div className="footer-section">
            <h3>Follow Us</h3>
            <div className="social-links">
              <a href="#">Facebook</a>
              <a href="#">Instagram</a>
              <a href="#">Twitter</a>
            </div>
          </div>
        </div>
        
        <div className="footer-bottom">
          <p>&copy; {new Date().getFullYear()} Studio World. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
};

export default Layout;
