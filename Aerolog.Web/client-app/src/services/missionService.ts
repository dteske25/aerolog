import { get } from '../apiHelper';
import type { IMission } from '../types/mission';

export const getMissionsBySeriesId = async (seriesId: string) => {
  const response = await get<IMission[]>('/api/Mission', { seriesId });
  return response;
};

export const getMission = async (id: string) => {
  const response = await get<IMission>(`/api/Mission/${id}`);
  return response;
};
