import axios from 'axios';

export const get = async <T>(url: string, params?: any) => {
  const response = await axios.get<T>(url, {
    params,
  });
  return response.data;
};
