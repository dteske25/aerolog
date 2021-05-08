import { gql } from '@apollo/client';

export const LOG_BY_ID_QUERY = gql`
  query logById($logId: String) {
    log(logId: $logId) {
      speakerName
      text
      timestamp
    }
  }
`;
