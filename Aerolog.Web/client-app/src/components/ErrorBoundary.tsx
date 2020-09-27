import React, { ErrorInfo } from 'react';
import { Alert, AlertTitle } from '@material-ui/lab';

export interface IErrorBoundaryProps {
  message?: string;
}

interface IErrorBoundaryState {
  hasError: false;
}

export default class ErrorBoundary extends React.Component<IErrorBoundaryProps, IErrorBoundaryState> {
  state: Readonly<IErrorBoundaryState> = {
    hasError: false,
  };

  static getDerivedStateFromError(error: any) {
    return { hasError: true };
  }

  componentDidCatch(error: Error, errorInfo: ErrorInfo) {
    console.log({
      message: this.props.message,
      error,
      errorInfo,
    });
  }

  render() {
    const { message, children } = this.props;
    if (this.state.hasError) {
      return (
        <Alert severity="error">
          <AlertTitle>Error</AlertTitle>
          {message ?? 'An error has occurred.'}
        </Alert>
      );
    }
    return children;
  }
}
