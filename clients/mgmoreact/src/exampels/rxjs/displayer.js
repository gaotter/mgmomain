import React from "react";
import { StaticPingService } from "./data-service";

export default class DataDisplayer extends React.Component {
  constructor() {
    super();
    this.state = {
      data: null,
    };
  }

  componentWillMount() {
    StaticPingService.pingData$.subscribe((d) => {
      this.setState((state) => ({
        data: d,
      }));
    });
  }

  render() {
    const para = this.state.data ? <p>{this.state.data}</p> : null;
    return <div>{para}</div>;
  }
}
