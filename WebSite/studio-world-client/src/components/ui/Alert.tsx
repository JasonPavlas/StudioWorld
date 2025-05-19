import React from 'react';
import Button from './Button';

interface AlertProps {
  title?: string;
  message: string;
  type?: 'info' | 'success' | 'warning' | 'error';
  onClose?: () => void;
  className?: string;
}

const Alert: React.FC<AlertProps> = ({
  title,
  message,
  type = 'info',
  onClose,
  className = '',
}) => {
  let alertClass = 'alert';
  
  // Add type classes
  switch (type) {
    case 'info':
      alertClass += ' alert-info';
      break;
    case 'success':
      alertClass += ' alert-success';
      break;
    case 'warning':
      alertClass += ' alert-warning';
      break;
    case 'error':
      alertClass += ' alert-error';
      break;
    default:
      alertClass += ' alert-info';
  }
  
  if (className) {
    alertClass += ` ${className}`;
  }
  
  return (
    <div className={alertClass} role="alert">
      <div className="alert-content">
        {title && <h4 className="alert-title">{title}</h4>}
        <p className="alert-message">{message}</p>
      </div>
      {onClose && (
        <button 
          className="alert-close" 
          onClick={onClose}
          aria-label="Close alert"
        >
          &times;
        </button>
      )}
    </div>
  );
};

export default Alert;
