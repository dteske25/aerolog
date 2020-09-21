import { get} from "../apiHelper";

export interface ISeries {
  id: string;
  seriesName: string;
}

export const getAllSeries = async () => {
  const response = await get<ISeries[]>('/api/Series');
  return response;
}

export const getSeries = async (id: string) => {
  const response = await get<ISeries>(`/api/Series/${id}`);
  return response;
}