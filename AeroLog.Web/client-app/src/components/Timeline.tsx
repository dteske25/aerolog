import React from 'react';
import { Mark, Slider, Tooltip, ValueLabelProps } from '@material-ui/core';
import { IEvent } from '../services/eventService';
import { format, getTime } from 'date-fns';

interface ITimelineProps {
  events: IEvent[];
  value: Date;
}

function ValueLabelComponent(props: ValueLabelProps) {
  const { children, open, value } = props;

  return (
    <Tooltip open={open} enterTouchDelay={0} placement="top" title={value}>
      {children}
    </Tooltip>
  );
}

class Timeline extends React.Component<ITimelineProps> {
  labelRefs: Map<string, HTMLDivElement | null>;
  constructor(props: Readonly<ITimelineProps>) {
    super(props);

    this.labelRefs = new Map<string, HTMLDivElement | null>();
  }

  setLabelRef = (id: string, element: HTMLDivElement | null) => {
    this.labelRefs.set(id, element);
  };

  componentDidMount() {
    console.log(this.labelRefs.keys());
  }

  componentDidUpdate() {
    console.log(this.labelRefs.keys());
  }

  render() {
    const marks: Mark[] = this.props.events.map((e, i) => ({
      value: getTime(new Date(e.timestamp)),
      label: (
        <div
          style={{
            textAlign: 'left',
            transform: `translate(0px,${(i % 4) * 15}px)`,
          }}
          ref={(e) => this.setLabelRef(i.toString(), e)}
        >
          <strong>{e.text}</strong>
        </div>
      ),
    }));
    const min = Math.min(...marks.map((m) => m.value));
    const max = Math.max(...marks.map((m) => m.value));
    return (
      <Slider
        min={min}
        max={max}
        defaultValue={min}
        step={100000}
        valueLabelDisplay="auto"
        ValueLabelComponent={ValueLabelComponent}
        valueLabelFormat={(v) => {
          if (v) {
            return format(v, 'PPp');
          }

          return v;
        }}
        marks={marks}
      />
    );
  }
}

export default Timeline;
