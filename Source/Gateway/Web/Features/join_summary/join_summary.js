export class join_summary {
  almostThere = false;

  activate(params, routeData) {
    this.almostThere = routeData.almostThere;
  }
}
