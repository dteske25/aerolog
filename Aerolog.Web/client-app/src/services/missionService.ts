import { gql } from '@apollo/client';

export const MISSION_BY_ID_QUERY = gql`
  query missionById($missionId: String) {
    mission(missionId: $missionId) {
      id
      missionName
      speakers {
        name
        label
      }
      log {
        timestamp
        speakerName
        text
        id
      }
    }
  }
`;
