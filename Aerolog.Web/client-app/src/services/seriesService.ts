import { get } from '../apiHelper';
import type { ISeries } from '../types/series';

export const getAllSeries = async () => {
  const response = await get<ISeries[]>('/api/Series');
  return response;
};

export const getSeries = async (id: string) => {
  const response = await get<ISeries>(`/api/Series/${id}`);
  return response;
};
