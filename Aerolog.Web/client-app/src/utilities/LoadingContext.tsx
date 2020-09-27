import React from 'react';
import { Subtract } from 'utility-types';

export const LoadingContext = React.createContext({ isLoading: false, setLoading: (val: boolean) => {} });

interface ILoadingProviderProps {}

export const LoadingProvider = (props: React.PropsWithChildren<ILoadingProviderProps>) => {
  const [isLoading, setLoading] = React.useState(false);
  const loading = React.useMemo(
    () => ({
      isLoading,
      setLoading,
    }),
    [isLoading],
  );
  return <LoadingContext.Provider value={loading}>{props.children}</LoadingContext.Provider>;
};

export interface IInjectedLoadingProps {
  isLoading: boolean;
  setLoading: (val: boolean) => void;
}

export const withLoading = <P extends IInjectedLoadingProps>(Component: React.ComponentType<P>) =>
  class WithLoading extends React.Component<Subtract<P, IInjectedLoadingProps>> {
    render() {
      return (
        <LoadingContext.Consumer>
          {(loadingProps) => <Component {...(this.props as P)} {...loadingProps} />}
        </LoadingContext.Consumer>
      );
    }
  };
