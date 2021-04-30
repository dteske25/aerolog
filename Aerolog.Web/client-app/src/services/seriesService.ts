import { gql } from '@apollo/client';

export const ALL_SERIES_QUERY = gql`
  query allSeries {
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

export const SERIES_BY_ID_QUERY = gql`
  query seriesById($seriesId: String) {
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
