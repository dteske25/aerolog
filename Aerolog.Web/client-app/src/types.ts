import { FieldPolicy, FieldReadFunction, TypePolicies, TypePolicy } from '@apollo/client/cache';
import { TypedDocumentNode as DocumentNode } from '@graphql-typed-document-node/core';
export type Maybe<T> = T | null;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  /** The `DateTime` scalar type represents a date and time. `DateTime` expects timestamps to be formatted in accordance with the [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard. */
  DateTime: any;
  Long: any;
};

/** Major events that occurred during the mission */
export type Event = {
  __typename?: 'Event';
  id: Scalars['String'];
  image: Scalars['String'];
  /** Mission the event occurred on. */
  mission?: Maybe<Mission>;
  /** Series of missions associated with the event. */
  series?: Maybe<Series>;
  text: Scalars['String'];
  timestamp: Scalars['DateTime'];
};

/** Transcribed logs from a mission */
export type Log = {
  __typename?: 'Log';
  id: Scalars['String'];
  /** The mission during which the log was captured */
  mission?: Maybe<Mission>;
  speakerName: Scalars['String'];
  text: Scalars['String'];
  timestamp: Scalars['DateTime'];
};

/** A set of missions that contributed to a larger objective */
export type Mission = {
  __typename?: 'Mission';
  id: Scalars['String'];
  /** Image associated with the mission. */
  image: Scalars['String'];
  /** Logs that were captured as part of this mission. */
  log?: Maybe<Array<Maybe<Log>>>;
  /** Number of logs that were captured as part of this mission. */
  logCount?: Maybe<Scalars['Long']>;
  /** The name of the mission. */
  missionName: Scalars['String'];
  /** The series this mission was a part of. */
  series?: Maybe<Series>;
  /** Speakers whose voice was recorded in logs during this mission. */
  speakers?: Maybe<Array<Maybe<Speaker>>>;
};

export type Query = {
  __typename?: 'Query';
  event?: Maybe<Array<Maybe<Event>>>;
  log?: Maybe<Array<Maybe<Log>>>;
  mission?: Maybe<Array<Maybe<Mission>>>;
  series?: Maybe<Array<Maybe<Series>>>;
};


export type QueryEventArgs = {
  eventId?: Maybe<Scalars['String']>;
  missionId?: Maybe<Scalars['String']>;
};


export type QueryLogArgs = {
  logId?: Maybe<Scalars['String']>;
  missionId?: Maybe<Scalars['String']>;
  seriesId?: Maybe<Scalars['String']>;
};


export type QueryMissionArgs = {
  missionId?: Maybe<Scalars['String']>;
  seriesId?: Maybe<Scalars['String']>;
};


export type QuerySeriesArgs = {
  seriesId?: Maybe<Scalars['String']>;
};

/** A set of missions that contributed to a larger objective */
export type Series = {
  __typename?: 'Series';
  id: Scalars['String'];
  /** Image associated with the mission. */
  image: Scalars['String'];
  /** Number of missions that are part of this series. */
  missionCount?: Maybe<Scalars['Long']>;
  /** Which missions are part of this series. */
  missions?: Maybe<Array<Maybe<Mission>>>;
  /** The name of the series. */
  seriesName: Scalars['String'];
};

/** Person(s) who participated in mission */
export type Speaker = {
  __typename?: 'Speaker';
  /** Short identifier used for logs */
  label: Scalars['String'];
  /** Name of speaker */
  name: Scalars['String'];
};

export type AllSeriesQueryVariables = Exact<{ [key: string]: never; }>;


export type AllSeriesQuery = { __typename?: 'Query', series?: Array<{ __typename?: 'Series', id: string, seriesName: string, image: string, missionCount?: any | null | undefined } | null | undefined> | null | undefined };

export type LogByIdQueryVariables = Exact<{
  logId?: Maybe<Scalars['String']>;
}>;


export type LogByIdQuery = { __typename?: 'Query', log?: Array<{ __typename?: 'Log', speakerName: string, text: string, timestamp: any } | null | undefined> | null | undefined };

export type MissionByIdQueryVariables = Exact<{
  missionId?: Maybe<Scalars['String']>;
}>;


export type MissionByIdQuery = { __typename?: 'Query', mission?: Array<{ __typename?: 'Mission', id: string, missionName: string, speakers?: Array<{ __typename?: 'Speaker', name: string, label: string } | null | undefined> | null | undefined, log?: Array<{ __typename?: 'Log', timestamp: any, speakerName: string, text: string, id: string } | null | undefined> | null | undefined } | null | undefined> | null | undefined };

export type SeriesByIdQueryVariables = Exact<{
  seriesId?: Maybe<Scalars['String']>;
}>;


export type SeriesByIdQuery = { __typename?: 'Query', series?: Array<{ __typename?: 'Series', id: string, seriesName: string, missions?: Array<{ __typename?: 'Mission', id: string, image: string, missionName: string, logCount?: any | null | undefined } | null | undefined> | null | undefined } | null | undefined> | null | undefined };

export type EventKeySpecifier = ('id' | 'image' | 'mission' | 'series' | 'text' | 'timestamp' | EventKeySpecifier)[];
export type EventFieldPolicy = {
	id?: FieldPolicy<any> | FieldReadFunction<any>,
	image?: FieldPolicy<any> | FieldReadFunction<any>,
	mission?: FieldPolicy<any> | FieldReadFunction<any>,
	series?: FieldPolicy<any> | FieldReadFunction<any>,
	text?: FieldPolicy<any> | FieldReadFunction<any>,
	timestamp?: FieldPolicy<any> | FieldReadFunction<any>
};
export type LogKeySpecifier = ('id' | 'mission' | 'speakerName' | 'text' | 'timestamp' | LogKeySpecifier)[];
export type LogFieldPolicy = {
	id?: FieldPolicy<any> | FieldReadFunction<any>,
	mission?: FieldPolicy<any> | FieldReadFunction<any>,
	speakerName?: FieldPolicy<any> | FieldReadFunction<any>,
	text?: FieldPolicy<any> | FieldReadFunction<any>,
	timestamp?: FieldPolicy<any> | FieldReadFunction<any>
};
export type MissionKeySpecifier = ('id' | 'image' | 'log' | 'logCount' | 'missionName' | 'series' | 'speakers' | MissionKeySpecifier)[];
export type MissionFieldPolicy = {
	id?: FieldPolicy<any> | FieldReadFunction<any>,
	image?: FieldPolicy<any> | FieldReadFunction<any>,
	log?: FieldPolicy<any> | FieldReadFunction<any>,
	logCount?: FieldPolicy<any> | FieldReadFunction<any>,
	missionName?: FieldPolicy<any> | FieldReadFunction<any>,
	series?: FieldPolicy<any> | FieldReadFunction<any>,
	speakers?: FieldPolicy<any> | FieldReadFunction<any>
};
export type QueryKeySpecifier = ('event' | 'log' | 'mission' | 'series' | QueryKeySpecifier)[];
export type QueryFieldPolicy = {
	event?: FieldPolicy<any> | FieldReadFunction<any>,
	log?: FieldPolicy<any> | FieldReadFunction<any>,
	mission?: FieldPolicy<any> | FieldReadFunction<any>,
	series?: FieldPolicy<any> | FieldReadFunction<any>
};
export type SeriesKeySpecifier = ('id' | 'image' | 'missionCount' | 'missions' | 'seriesName' | SeriesKeySpecifier)[];
export type SeriesFieldPolicy = {
	id?: FieldPolicy<any> | FieldReadFunction<any>,
	image?: FieldPolicy<any> | FieldReadFunction<any>,
	missionCount?: FieldPolicy<any> | FieldReadFunction<any>,
	missions?: FieldPolicy<any> | FieldReadFunction<any>,
	seriesName?: FieldPolicy<any> | FieldReadFunction<any>
};
export type SpeakerKeySpecifier = ('label' | 'name' | SpeakerKeySpecifier)[];
export type SpeakerFieldPolicy = {
	label?: FieldPolicy<any> | FieldReadFunction<any>,
	name?: FieldPolicy<any> | FieldReadFunction<any>
};
export type StrictTypedTypePolicies = {
	Event?: Omit<TypePolicy, "fields" | "keyFields"> & {
		keyFields?: false | EventKeySpecifier | (() => undefined | EventKeySpecifier),
		fields?: EventFieldPolicy,
	},
	Log?: Omit<TypePolicy, "fields" | "keyFields"> & {
		keyFields?: false | LogKeySpecifier | (() => undefined | LogKeySpecifier),
		fields?: LogFieldPolicy,
	},
	Mission?: Omit<TypePolicy, "fields" | "keyFields"> & {
		keyFields?: false | MissionKeySpecifier | (() => undefined | MissionKeySpecifier),
		fields?: MissionFieldPolicy,
	},
	Query?: Omit<TypePolicy, "fields" | "keyFields"> & {
		keyFields?: false | QueryKeySpecifier | (() => undefined | QueryKeySpecifier),
		fields?: QueryFieldPolicy,
	},
	Series?: Omit<TypePolicy, "fields" | "keyFields"> & {
		keyFields?: false | SeriesKeySpecifier | (() => undefined | SeriesKeySpecifier),
		fields?: SeriesFieldPolicy,
	},
	Speaker?: Omit<TypePolicy, "fields" | "keyFields"> & {
		keyFields?: false | SpeakerKeySpecifier | (() => undefined | SpeakerKeySpecifier),
		fields?: SpeakerFieldPolicy,
	}
};
export type TypedTypePolicies = StrictTypedTypePolicies & TypePolicies;

export const AllSeriesDocument = {"kind":"Document","definitions":[{"kind":"OperationDefinition","operation":"query","name":{"kind":"Name","value":"allSeries"},"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"series"},"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"id"}},{"kind":"Field","name":{"kind":"Name","value":"seriesName"}},{"kind":"Field","name":{"kind":"Name","value":"image"}},{"kind":"Field","name":{"kind":"Name","value":"missionCount"}}]}}]}}]} as unknown as DocumentNode<AllSeriesQuery, AllSeriesQueryVariables>;
export const LogByIdDocument = {"kind":"Document","definitions":[{"kind":"OperationDefinition","operation":"query","name":{"kind":"Name","value":"logById"},"variableDefinitions":[{"kind":"VariableDefinition","variable":{"kind":"Variable","name":{"kind":"Name","value":"logId"}},"type":{"kind":"NamedType","name":{"kind":"Name","value":"String"}}}],"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"log"},"arguments":[{"kind":"Argument","name":{"kind":"Name","value":"logId"},"value":{"kind":"Variable","name":{"kind":"Name","value":"logId"}}}],"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"speakerName"}},{"kind":"Field","name":{"kind":"Name","value":"text"}},{"kind":"Field","name":{"kind":"Name","value":"timestamp"}}]}}]}}]} as unknown as DocumentNode<LogByIdQuery, LogByIdQueryVariables>;
export const MissionByIdDocument = {"kind":"Document","definitions":[{"kind":"OperationDefinition","operation":"query","name":{"kind":"Name","value":"missionById"},"variableDefinitions":[{"kind":"VariableDefinition","variable":{"kind":"Variable","name":{"kind":"Name","value":"missionId"}},"type":{"kind":"NamedType","name":{"kind":"Name","value":"String"}}}],"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"mission"},"arguments":[{"kind":"Argument","name":{"kind":"Name","value":"missionId"},"value":{"kind":"Variable","name":{"kind":"Name","value":"missionId"}}}],"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"id"}},{"kind":"Field","name":{"kind":"Name","value":"missionName"}},{"kind":"Field","name":{"kind":"Name","value":"speakers"},"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"name"}},{"kind":"Field","name":{"kind":"Name","value":"label"}}]}},{"kind":"Field","name":{"kind":"Name","value":"log"},"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"timestamp"}},{"kind":"Field","name":{"kind":"Name","value":"speakerName"}},{"kind":"Field","name":{"kind":"Name","value":"text"}},{"kind":"Field","name":{"kind":"Name","value":"id"}}]}}]}}]}}]} as unknown as DocumentNode<MissionByIdQuery, MissionByIdQueryVariables>;
export const SeriesByIdDocument = {"kind":"Document","definitions":[{"kind":"OperationDefinition","operation":"query","name":{"kind":"Name","value":"seriesById"},"variableDefinitions":[{"kind":"VariableDefinition","variable":{"kind":"Variable","name":{"kind":"Name","value":"seriesId"}},"type":{"kind":"NamedType","name":{"kind":"Name","value":"String"}}}],"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"series"},"arguments":[{"kind":"Argument","name":{"kind":"Name","value":"seriesId"},"value":{"kind":"Variable","name":{"kind":"Name","value":"seriesId"}}}],"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"id"}},{"kind":"Field","name":{"kind":"Name","value":"seriesName"}},{"kind":"Field","name":{"kind":"Name","value":"missions"},"selectionSet":{"kind":"SelectionSet","selections":[{"kind":"Field","name":{"kind":"Name","value":"id"}},{"kind":"Field","name":{"kind":"Name","value":"image"}},{"kind":"Field","name":{"kind":"Name","value":"missionName"}},{"kind":"Field","name":{"kind":"Name","value":"logCount"}}]}}]}}]}}]} as unknown as DocumentNode<SeriesByIdQuery, SeriesByIdQueryVariables>;