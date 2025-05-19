import React, { InputHTMLAttributes } from 'react';

interface InputFieldProps extends InputHTMLAttributes<HTMLInputElement> {
  label?: string;
  error?: string;
  containerClassName?: string;
}

const InputField: React.FC<InputFieldProps> = ({
  label,
  error,
  id,
  name,
  containerClassName = '',
  className = '',
  ...rest
}) => {
  const inputId = id || name;

  return (
    <div className={`input-field-container ${containerClassName}`}>
      {label && (
        <label htmlFor={inputId} className="input-label">
          {label}
        </label>
      )}
      <input
        id={inputId}
        name={name}
        className={`input-field ${error ? 'input-error' : ''} ${className}`}
        aria-invalid={!!error}
        aria-describedby={error ? `${inputId}-error` : undefined}
        {...rest}
      />
      {error && (
        <p id={`${inputId}-error`} className="input-error-message">
          {error}
        </p>
      )}
    </div>
  );
};

export default InputField;
