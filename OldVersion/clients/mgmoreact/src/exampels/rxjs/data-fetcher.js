import React from "react";
import { StaticPingService } from "./data-service";

export default class DataFetcher extends React.Component {
  triggerFerchData() {
    StaticPingService.fetchPing("Yo I'm trigged form DataFetcher.");
  }

  render() {
    return (
      <div>
        <button onClick={() => this.triggerFerchData()}>Get some data</button>
      </div>
    );
  }
}
