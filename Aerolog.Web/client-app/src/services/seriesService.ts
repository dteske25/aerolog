import { gql } from '@apollo/client';

export const allSeriesQuery = gql`
  query allSeriesQuery {
    series {
      id
      seriesName
      file {
        id
        contentType
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
          contentType
          fileName
        }
        missionName
        logCount
      }
    }
  }
`;
