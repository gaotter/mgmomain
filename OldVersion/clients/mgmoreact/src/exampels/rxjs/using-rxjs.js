import React from "react";
import DataFetcher from "./data-fetcher";
import DataDisplayer from "./displayer";

export default class UseRxjs extends React.Component {
  render() {
    return (
      <div>
        <h1>Rxjs in React</h1>
        <DataFetcher></DataFetcher>
        <DataDisplayer></DataDisplayer>
        <DataDisplayer></DataDisplayer>
        <DataDisplayer></DataDisplayer>
        <DataDisplayer></DataDisplayer>
      </div>
    );
  }
}
