interface ValueResultResponseModel<T> {
  /**
   * Indicates if the operation was successful
   */
  isSuccess: boolean;

  /**
   * The value of the result, if any
   */
  value: T | null;

  /**
   * A list of errors, if any
   */
  errors: Array<string | null>;
}

interface VoidResultResponseModel {
  /**
   * Indicates if the operation was successful
   */
  isSuccess: boolean;

  /**
   * A list of errors, if any
   */
  errors: Array<string | null>;
}

export { ValueResultResponseModel, VoidResultResponseModel };
