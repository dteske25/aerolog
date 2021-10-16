import React, { useState } from 'react';
import { useRouteMatch } from 'react-router';
import { useQuery } from '@apollo/client';
import ErrorBoundary from './ErrorBoundary';
import { Grid } from '@material-ui/core';
import format from 'date-fns/format';
import { DataGrid, GridColDef } from '@material-ui/data-grid';
import Log from './Log';
import { Skeleton } from '@material-ui/lab';
import {
  MissionByIdDocument,
  Log as LogType,
  Speaker as SpeakerType,
} from '../types';

interface IMissionUrlProps {
  id: string;
}

const columns: GridColDef[] = [
  {
    field: 'timestamp',
    headerName: 'Date',
    flex: 1,
    // valueGetter: (params) => {
    //   const dateTime = params.getValue('timestamp')?.toString() ?? '';
    //   return format(new Date(dateTime), 'Pp');
    // },
    valueFormatter: (params) => {
      return format(new Date(params.value?.toString() ?? ''), 'Ppp');
    },
  },
  { field: 'speakerName', headerName: 'Speaker', width: 150 },
  { field: 'text', headerName: 'Text', flex: 3 },
];

const Mission = () => {
  const match = useRouteMatch<IMissionUrlProps>();
  const [selectionModel, setSelectionModel] = useState<(string | number)[]>();
  const { loading, data, error } = useQuery(MissionByIdDocument, {
    variables: { missionId: match.params.id },
  });

  if (error) {
    throw error.message;
  }

  const currentMission = data?.mission?.[0];

  const logData =
    currentMission?.log?.filter(
      (log): log is LogType => log !== null && log !== undefined,
    ) ?? [];

  const speakers =
    currentMission?.speakers?.filter(
      (s): s is SpeakerType => s !== null && s !== undefined,
    ) ?? [];
  return (
    <ErrorBoundary message="Error loading mission">
      <Grid container spacing={3}>
        <Grid item xs={12} md={8}>
          <div style={{ height: '75vh', width: '100%' }}>
            {loading && <Skeleton variant="rect" height="100%" />}
            {!loading && (
              <DataGrid
                rows={logData}
                columns={columns}
                selectionModel={selectionModel}
                onSelectionModelChange={(newSelection) =>
                  setSelectionModel(newSelection)
                }
              />
            )}
          </div>
        </Grid>
        <Grid item xs={12} md={4}>
          {currentMission?.speakers &&
            selectionModel?.map((s) => (
              <Log key={s} logId={s.toString()} speakers={speakers} />
            ))}
        </Grid>
      </Grid>
    </ErrorBoundary>
  );
};

export default Mission;
