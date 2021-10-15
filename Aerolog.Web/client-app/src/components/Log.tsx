import React from 'react';
import { useQuery } from '@apollo/client';
import {
  Avatar,
  Card,
  CardContent,
  CardHeader,
  CircularProgress,
  Typography,
} from '@material-ui/core';
import format from 'date-fns/format';
import { parseISO } from 'date-fns';
import { LogByIdDocument } from '../types';

interface ILogProps {
  logId: string;
  speakers: { name: string; label: string }[];
}

const Log = (props: ILogProps) => {
  const { loading, data } = useQuery(LogByIdDocument, {
    variables: { logId: props.logId },
  });

  if (loading) {
    return <CircularProgress />;
  }

  const log = data?.log?.[0];
  const fullName = props.speakers.find((s) => s.label === log?.speakerName)
    ?.name;
  return (
    <Card>
      <CardHeader
        avatar={<Avatar>{log?.speakerName}</Avatar>}
        title={fullName}
        subheader={format(parseISO(log?.timestamp ?? ''), 'Ppp')}
      />
      <CardContent>
        <Typography>{log?.text}</Typography>
      </CardContent>
    </Card>
  );
};

export default Log;
