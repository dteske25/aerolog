import type { IFile } from './file';

export interface ISeries {
  id: string;
  seriesName: string;
  fileId: string;
  file: IFile;
}
