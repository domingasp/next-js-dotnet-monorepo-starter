import { screen, render } from '@testing-library/react';
import Button from './Button';

describe('Button', () => {
  it('should have "Test" as label', () => {
    // Arrange
    render(<Button>Test</Button>);

    // Act

    // Assert
    const btn = screen.getByRole('button');
    expect(btn.innerHTML).toContain('Test');
  });
});
