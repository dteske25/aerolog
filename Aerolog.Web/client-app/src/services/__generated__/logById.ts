/* tslint:disable */
/* eslint-disable */
// @generated
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: logById
// ====================================================

export interface logById_log {
  __typename: "Log";
  speakerName: string;
  text: string;
  timestamp: any;
}

export interface logById {
  log: (logById_log | null)[] | null;
}

export interface logByIdVariables {
  logId?: string | null;
}
