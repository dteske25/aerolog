import axios from 'axios';
import { ApolloClient, InMemoryCache } from '@apollo/client';

export const get = async <T>(url: string, params?: any) => {
  const response = await axios.get<T>(url, {
    params,
  });
  return response.data;
};

export const client = new ApolloClient({
  uri: '/graphql',
  cache: new InMemoryCache(),
});
