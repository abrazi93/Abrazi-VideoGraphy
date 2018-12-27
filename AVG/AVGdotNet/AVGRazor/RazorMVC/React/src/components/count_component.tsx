import * as React from 'react';

type CountProps = {}
type CountState = {count:number}

export class Count extends React.Component<CountProps,CountState>{
    constructor(props: CountProps){
        super();
        this.state = {count:0}
        this.handleEvent.bind(this);
    }

    handleEvent = function(): void{
        this.setState({...this.state, count:this.state.count+1});
        document.getElementById("test").style.backgroundColor = "purple";
    }

    render(){
        return <div id="test">
            <h1>Count {this.state.count}</h1>
            <button onClick={()=>this.handleEvent()}>Click</button>
            <MyInput count={this.state.count}/>
        </div>
    }
}

type MyInputProps = {count:number}
type MyInputState = {}

class MyInput extends React.Component<MyInputProps, MyInputState>{
    constructor(props: MyInputProps){
        super();
    }

    render(){
        return <form>
            <input type="text" value={this.props.count}/>
        </form>
    }
}