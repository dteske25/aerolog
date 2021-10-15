import { ApolloClient, InMemoryCache } from '@apollo/client';
import { TypedTypePolicies } from './types';

const typePolicies: TypedTypePolicies = {
  Event: {
    keyFields: ['id'],
  },
  Log: {
    keyFields: ['id'],
  },
  Mission: {
    keyFields: ['id'],
  },
  Series: {
    keyFields: ['id'],
  },
  Speaker: {
    keyFields: ['label', 'name'],
  },
};

export const client = new ApolloClient({
  uri: '/graphql',
  cache: new InMemoryCache({
    typePolicies,
  }),
});
