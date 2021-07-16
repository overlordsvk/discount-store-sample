import React, { Component } from 'react';

export class Cart extends Component {
    static displayName = Cart.name;

    constructor(props) {
      super(props);
      this.state = { items: [], loading: true, price: 0, loadingPrice: true};
    }
  
    componentDidMount() {
      this.getData();
      this.getPrice();
    }



    async getData() {
        const response = await fetch('api/cart');
        const data = await response.json();
        this.setState({ items: data, loading: false });
    }
  
    async getPrice() {
        const response = await fetch('api/cart/price');
        const data = await response.json();
        this.setState({ price: data, loadingPrice: false });
    }
  
    static renderItemTable(items) {
      return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Id</th>
              <th>SKU</th>
              <th>Price</th>
              <th>Count</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {items.map(item =>
              <tr key={item.id}>
                <td>{item.id}</td>
                <td>{item.sku}</td>
                <td>{item.price}</td>
                <td>{item.count}</td>
                <td>
                  <button onClick={() => addItem(item)}>+</button>
                  <button onClick={() => removeItem(item.id)}>-</button>
                </td>
              </tr>
            )}
          </tbody>
        </table>
      );
    }
  
    render() {
      let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : Cart.renderItemTable(this.state.items);
        let priceContent = this.state.loadingPrice
        ? <p><em>Loading...</em></p>
        : this.state.price;
      return (
        <>
        <div>
          <h1 id="tabelLabel" >Cart items</h1>
          {contents}
        </div>
        <button onClick={() => refreshPage()}>Refresh</button>
        <div>
            <h2>Price</h2>
            <span>{priceContent}</span>
        </div>
        </>
      );
    }
}

function addItem(item) {
  const requestOptions = {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(item)
  };
  fetch('api/cart', requestOptions);
}
function removeItem(itemId) {
  const requestOptions = {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(itemId)
  };
  fetch('api/cart', requestOptions);
}

function refreshPage() {
  window.location.reload();
}