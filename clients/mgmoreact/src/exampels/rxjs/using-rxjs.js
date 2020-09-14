import React from "react";
import DataFetcher from "./data-fetcher";
import DataDisplayer from "./displayer";

export default class UseRxjs extends React.Component {
  render() {
    return (
      <div>
        <DataFetcher></DataFetcher>
        <DataDisplayer></DataDisplayer>
        <DataDisplayer></DataDisplayer>
        <DataDisplayer></DataDisplayer>
        <DataDisplayer></DataDisplayer>
      </div>
    );
  }
}
