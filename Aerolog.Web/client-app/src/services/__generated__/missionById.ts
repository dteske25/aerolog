/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: missionById
// ====================================================

export interface missionById_mission_speakers {
  __typename: "Speaker";
  /**
   * Name of speaker
   */
  name: string;
  /**
   * Short identifier used for logs
   */
  label: string;
}

export interface missionById_mission_log {
  __typename: "Log";
  timestamp: any;
  speakerName: string;
  text: string;
  id: string;
}

export interface missionById_mission {
  __typename: "Mission";
  id: string;
  /**
   * The name of the mission.
   */
  missionName: string;
  /**
   * Speakers whose voice was recorded in logs during this mission.
   */
  speakers: (missionById_mission_speakers | null)[] | null;
  /**
   * Logs that were captured as part of this mission.
   */
  log: (missionById_mission_log | null)[] | null;
}

export interface missionById {
  mission: (missionById_mission | null)[] | null;
}

export interface missionByIdVariables {
  missionId?: string | null;
}
