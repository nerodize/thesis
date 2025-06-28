bool ShouldReconcile()
{
   bool isNewServerState = !_lastServerState.Equals(default);
   bool isLastStateUndefinedOrDifferent = 
        _lastProcessedState.Equals(default) 
        || !_lastProcessedState.Equals(_lastServerState);
        return isNewServerState && 
               isLastStateUndefinedOrDifferent;
}