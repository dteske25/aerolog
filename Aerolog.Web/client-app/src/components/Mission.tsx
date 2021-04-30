import React from 'react';
import { useRouteMatch } from 'react-router';
import { MISSION_BY_ID_QUERY } from '../services/missionService';
import { useQuery } from '@apollo/client';
import TitleBar from './TitleBar';
import ErrorBoundary from './ErrorBoundary';
import { IMission } from '../types/mission';
import { Grid, Button, useTheme, makeStyles } from '@material-ui/core';
import ImageCard, { ImageCardSkeleton } from './ImageCard';
import routes from '../utilities/routes';
import { Link } from 'react-router-dom';
import format from 'date-fns/format';
import { DataGrid, GridRowData, GridColDef } from '@material-ui/data-grid';
import { missionById, missionByIdVariables, missionById_mission_log } from '../services/__generated__/missionById';

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
  const { loading, data, error } = useQuery<missionById, missionByIdVariables>(MISSION_BY_ID_QUERY, {
    variables: { missionId: match.params.id },
  });

  const theme = useTheme();
  const classes = useStyles(theme);

  if (error) {
    throw error.message;
  }

  let mission = null;
  if (data?.mission) {
    mission = data.mission[0];
  }
  const logData = mission?.log?.filter((log): log is missionById_mission_log => log !== null) ?? [];

  return (
    <ErrorBoundary message="Error loading mission">
      <TitleBar title={mission?.missionName} isLoading={loading} includeSearching={false} />

      <div style={{ height: '100%', width: '100%' }}>
        <DataGrid rows={logData} columns={columns} pageSize={100} />
      </div>
    </ErrorBoundary>
  );
};

export default Mission;
