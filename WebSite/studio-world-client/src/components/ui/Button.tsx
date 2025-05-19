import React, { ButtonHTMLAttributes } from 'react';

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: 'primary' | 'secondary' | 'outline' | 'link';
  size?: 'small' | 'medium' | 'large';
  isLoading?: boolean;
  fullWidth?: boolean;
}

const Button: React.FC<ButtonProps> = ({
  children,
  variant = 'primary',
  size = 'medium',
  isLoading = false,
  fullWidth = false,
  className = '',
  disabled,
  ...rest
}) => {
  // Base classes
  let classes = 'button';
  
  // Add variant classes
  switch (variant) {
    case 'primary':
      classes += ' button-primary';
      break;
    case 'secondary':
      classes += ' button-secondary';
      break;
    case 'outline':
      classes += ' button-outline';
      break;
    case 'link':
      classes += ' button-link';
      break;
    default:
      classes += ' button-primary';
  }
  
  // Add size classes
  switch (size) {
    case 'small':
      classes += ' button-sm';
      break;
    case 'medium':
      classes += ' button-md';
      break;
    case 'large':
      classes += ' button-lg';
      break;
    default:
      classes += ' button-md';
  }
  
  // Add full width class
  if (fullWidth) {
    classes += ' button-full';
  }
  
  // Add loading class
  if (isLoading) {
    classes += ' button-loading';
  }
  
  // Add custom classes
  if (className) {
    classes += ` ${className}`;
  }

  return (
    <button 
      className={classes} 
      disabled={isLoading || disabled}
      {...rest}
    >
      {isLoading ? (
        <span className="button-loader">
          <span className="loader-dot"></span>
          <span className="loader-dot"></span>
          <span className="loader-dot"></span>
        </span>
      ) : children}
    </button>
  );
};

export default Button;
