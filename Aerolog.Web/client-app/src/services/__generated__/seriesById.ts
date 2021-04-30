/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: seriesById
// ====================================================

export interface seriesById_series_missions_file {
  __typename: "File";
  id: string;
  fileName: string;
}

export interface seriesById_series_missions {
  __typename: "Mission";
  id: string;
  /**
   * Image associated with the mission.
   */
  file: seriesById_series_missions_file | null;
  /**
   * The name of the mission.
   */
  missionName: string;
  /**
   * Number of logs that were captured as part of this mission.
   */
  logCount: any | null;
}

export interface seriesById_series {
  __typename: "Series";
  id: string;
  /**
   * The name of the series.
   */
  seriesName: string;
  /**
   * Which missions are part of this series.
   */
  missions: (seriesById_series_missions | null)[] | null;
}

export interface seriesById {
  series: (seriesById_series | null)[] | null;
}

export interface seriesByIdVariables {
  seriesId?: string | null;
}
