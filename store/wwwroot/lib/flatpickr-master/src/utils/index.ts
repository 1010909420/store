export const pad = (number: string | number) => `0${number}`.slice(-2);
export const int = (bool: boolean) => (bool === true ? 1 : 0);

/* istanbul ignore next */
export function debounce<F extends Function>(
  func: F,
  wait: number,
  immediate: boolean = false
) {
  let timeout: NodeJS.Timer | null;
  return function(this: Function) {
    let context = this,
      args = arguments;
    timeout !== null && clearTimeout(timeout);
    timeout = setTimeout(function() {
      timeout = null;
      if (!immediate) func.apply(context, args);
    }, wait);
    if (immediate && !timeout) func.apply(context, args);
  };
}

export const arrayify = <T>(obj: T | T[]): T[] =>
  obj instanceof Array ? obj : [obj];

export const mouseDelta = (e: MouseWheelEvent) =>
  Math.max(-1, Math.min(1, e.wheelDelta || -e.deltaY));

export type IncrementEvent = MouseEvent & { delta: number; type: "increment" };
