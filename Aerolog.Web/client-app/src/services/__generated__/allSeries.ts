/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: allSeries
// ====================================================

export interface allSeries_series_file {
  __typename: "File";
  id: string;
  fileName: string;
}

export interface allSeries_series {
  __typename: "Series";
  id: string;
  /**
   * The name of the series.
   */
  seriesName: string;
  /**
   * Image associated with the series.
   */
  file: allSeries_series_file | null;
  /**
   * Number of missions that are part of this series.
   */
  missionCount: any | null;
}

export interface allSeries {
  series: (allSeries_series | null)[] | null;
}
