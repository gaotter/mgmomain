import React from "react";
import { StaticPingService } from "./data-service";

export default class DataDisplayer extends React.Component {
  sub;

  constructor() {
    super();
    this.state = {
      data: null,
    };
  }

  componentWillMount() {
    this.sub = StaticPingService.pingData$.subscribe((d) => {
      this.setState((state) => ({
        data: d,
      }));
    });
  }

  componentWillUnmount() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }

  render() {
    const para = this.state.data ? <p>{this.state.data}</p> : null;
    return <div>{para}</div>;
  }
}
