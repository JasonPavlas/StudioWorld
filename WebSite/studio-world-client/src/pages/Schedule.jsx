import React from 'react';

const Schedule = () => {
  return (
    <div className="schedule-container">
      <h1>Schedule an Appointment</h1>
      
      <section className="booking-form">
        <h2>Book Your Service</h2>
        <form>
          <div className="form-group">
            <label htmlFor="service">Select Service</label>
            <select id="service" name="service">
              <option value="">-- Select a Service --</option>
              <option value="content-creation">Content Creation</option>
              <option value="tattooing">Tattooing</option>
              <option value="barbershop">Barbershop</option>
              <option value="cosmetology">Cosmetology</option>
              <option value="massage">Massage Therapy</option>
            </select>
          </div>
          
          <div className="form-group">
            <label htmlFor="date">Preferred Date</label>
            <input type="date" id="date" name="date" />
          </div>
          
          <div className="form-group">
            <label htmlFor="time">Preferred Time</label>
            <input type="time" id="time" name="time" />
          </div>
          
          <div className="form-group">
            <label htmlFor="name">Your Name</label>
            <input type="text" id="name" name="name" placeholder="Full Name" />
          </div>
          
          <div className="form-group">
            <label htmlFor="email">Email Address</label>
            <input type="email" id="email" name="email" placeholder="email@example.com" />
          </div>
          
          <div className="form-group">
            <label htmlFor="phone">Phone Number</label>
            <input type="tel" id="phone" name="phone" placeholder="(123) 456-7890" />
          </div>
          
          <div className="form-group">
            <label htmlFor="notes">Special Requests</label>
            <textarea id="notes" name="notes" placeholder="Any special requests or notes"></textarea>
          </div>
          
          <button type="submit">Submit Booking Request</button>
        </form>
      </section>
      
      <section className="business-hours">
        <h2>Business Hours</h2>
        <ul>
          <li><strong>Monday-Friday:</strong> 9:00 AM - 8:00 PM</li>
          <li><strong>Saturday:</strong> 10:00 AM - 6:00 PM</li>
          <li><strong>Sunday:</strong> 12:00 PM - 5:00 PM</li>
        </ul>
        <p><em>Note: Training weeks have special hours. Please check our Training page for details.</em></p>
      </section>
    </div>
  );
};

export default Schedule;
