import React, { useState } from 'react';
import { useRouteMatch } from 'react-router';
import { MISSION_BY_ID_QUERY } from '../services/missionService';
import { useQuery } from '@apollo/client';
import TitleBar from './TitleBar';
import ErrorBoundary from './ErrorBoundary';
import { IMission } from '../types/mission';
import {
  Grid,
  Button,
  useTheme,
  makeStyles,
  CircularProgress,
} from '@material-ui/core';
import format from 'date-fns/format';
import { DataGrid, GridColDef } from '@material-ui/data-grid';
import {
  missionById,
  missionByIdVariables,
  missionById_mission,
  missionById_mission_log,
  missionById_mission_speakers,
} from '../services/__generated__/missionById';
import Log from './Log';
import { Skeleton } from '@material-ui/lab';

const useStyles = makeStyles((theme) => ({
  headerRow: {
    display: 'flex',
    justifyContent: 'space-between',
  },
  search: {
    flex: '2 0 auto',
  },
  title: {
    flex: '1 0 auto',
  },
  link: {
    textDecoration: 'none',
  },
}));

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

interface IMissionProps {}

const Mission = (props: IMissionProps) => {
  const match = useRouteMatch<IMissionUrlProps>();
  const [selectionModel, setSelectionModel] = useState<(string | number)[]>();
  const { loading, data, error } = useQuery<missionById, missionByIdVariables>(
    MISSION_BY_ID_QUERY,
    {
      variables: { missionId: match.params.id },
    },
  );

  const theme = useTheme();
  const classes = useStyles(theme);
  if (error) {
    throw error.message;
  }

  let mission: missionById_mission | null = null;
  if (data?.mission) {
    mission = data.mission[0];
  }

  const logData =
    mission?.log?.filter(
      (log): log is missionById_mission_log => log !== null,
    ) ?? [];

  const speakers =
    mission?.speakers?.filter(
      (s): s is missionById_mission_speakers => s !== null,
    ) ?? [];

  return (
    <ErrorBoundary message="Error loading mission">
      <Grid container spacing={3}>
        <Grid item xs={12} md={6}>
          <div style={{ height: '75vh', width: '100%' }}>
            {loading && <Skeleton variant="rect" height="100%" />}
            {!loading && (
              <DataGrid
                rows={logData}
                columns={columns}
                selectionModel={selectionModel}
                onSelectionModelChange={(newSelection) => {
                  console.log(newSelection);
                  setSelectionModel(newSelection.selectionModel);
                }}
              />
            )}
          </div>
        </Grid>
        <Grid item xs={12} md={6}>
          {selectionModel &&
            mission?.speakers &&
            selectionModel.map((s, i) => (
              <Log key={i} logId={s.toString()} speakers={speakers} />
            ))}
        </Grid>
      </Grid>
    </ErrorBoundary>
  );
};

export default Mission;
