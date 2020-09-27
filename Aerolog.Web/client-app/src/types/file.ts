export interface IFile {
  /**
   * id refers to the actual record in the files table, containing the metadata
   */
  id: string;
  contentType: string;
  fileContent: string;
  /**
   * fileId refers to the record in the lfs that contains the content itself
   */
  fileId: string;
  fileName: string;
}
