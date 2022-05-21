import { screen, render } from '@testing-library/react';
import Home from '../pages';

describe('Home', () => {
  it('should have button on the page', () => {
    // Arrange
    render(<Home />);

    // Act

    // Assert
    const btn = screen.getByRole('button');
    expect(btn.innerHTML).toContain('Hello');
  });
});
