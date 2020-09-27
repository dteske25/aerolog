import type { IFile } from './file';

export interface IMission {
  id: string;
  seriesId: string;
  missionName: string;
  fileId: string;
  file: IFile;
}
