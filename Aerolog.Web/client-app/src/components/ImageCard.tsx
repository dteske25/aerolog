import React from 'react';
import Card from '@material-ui/core/Card/Card';
import CardActions from '@material-ui/core/CardActions/CardActions';
import CardContent from '@material-ui/core/CardContent/CardContent';
import CardMedia from '@material-ui/core/CardMedia/CardMedia';
import Typography from '@material-ui/core/Typography/Typography';
import { Skeleton } from '@material-ui/lab';
import { Fade, Grid } from '@material-ui/core';
import { IFile } from '../types/file';

interface IImageCardProps {
  file?: IFile;
  title: React.ReactNode;
  actions: React.ReactNode;
}

const ImageCard = (props: IImageCardProps) => {
  const { file, title, actions } = props;
  return (
    <Grid item xs={12} sm={6} md={4}>
      <Fade in>
        <Card>
          {file && <CardMedia component="img" image={`/api/file/${file.id}`} title={file.fileName} />}
          <CardContent>
            <Typography>{title}</Typography>
          </CardContent>
          <CardActions>{actions}</CardActions>
        </Card>
      </Fade>
    </Grid>
  );
};

export const ImageCardSkeleton = () => (
  <Grid item xs={12} sm={6} md={4}>
    <Card>
      <Skeleton variant="rect" height={250} />
      <CardContent>
        <Skeleton variant="text" height={36} />
      </CardContent>
      <CardActions>
        <Skeleton variant="text" height={24} width={100} />
      </CardActions>
    </Card>
  </Grid>
);
export default ImageCard;
