import React from 'react';

const About = () => {
  return (
    <div className="about-container">
      <h1>About Studio World</h1>
      
      <section className="mission">
        <h2>Our Mission</h2>
        <p>
          Our mission is to develop creative individuals through comprehensive services 
          and hands-on training in content creation, tattooing, barbering, cosmetology, 
          and massage therapy.
        </p>
      </section>
      
      <section className="vision">
        <h2>Our Vision</h2>
        <p>
          Our vision is to become the premier hub for artists of all ages. 
          Our goal is to make Studio World the go-to destination for both creative 
          services and youth-focused development.
        </p>
      </section>
      
      <section className="story">
        <h2>Our Story</h2>
        <p>
          Studio World was founded with the idea of creating a space where artists could 
          not only practice their craft but also train the next generation. We believe in 
          the power of mentorship and hands-on experience to develop skilled artists.
        </p>
        <p>
          We dedicate one week each month to training programs for emerging artists — 
          especially kids and teens — helping them grow their skills early and build 
          a foundation for their creative future.
        </p>
      </section>
      
      <section className="team">
        <h2>Our Team</h2>
        <p>
          Our team consists of experienced professionals in various artistic fields. 
          Each team member brings unique skills and perspectives to Studio World, 
          creating a diverse and vibrant creative community.
        </p>
        {/* Team member cards would go here in a full implementation */}
      </section>
    </div>
  );
};

export default About;
