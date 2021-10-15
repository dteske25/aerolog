const routes = {
  home: '/',
  info: '/info',
  about: '/about',

  seriesList: '/series',
  seriesDetails: '/series/:id',
  getSeriesDetails: (id?: string) => `/series/${id}`,

  missionDetails: '/mission/:id',
  getMissionDetails: (id?: string) => `/mission/${id}`,
};
export default routes;
