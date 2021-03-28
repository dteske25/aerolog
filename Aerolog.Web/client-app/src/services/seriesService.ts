import { gql } from '@apollo/client';

export const allSeriesQuery = gql`
  query allSeriesQuery {
    series {
      id
      seriesName
      file {
        id
        fileName
      }
      missionCount
    }
  }
`;

export const seriesQuery = gql`
  query seriesQuery($seriesId: String) {
    series(seriesId: $seriesId) {
      id
      seriesName
      missions {
        id
        file {
          id
          fileName
        }
        missionName
        logCount
      }
    }
  }
`;
