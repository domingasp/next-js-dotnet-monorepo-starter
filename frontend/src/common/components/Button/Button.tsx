import styles from './Button.module.css';

type ButtonProps = {
  children?: string;
};

function Button({ children = 'Button' }: ButtonProps) {
  return (
    <button type="button" className={styles.button}>
      {children}

      <style jsx>{`
        button {
          font-style: italic;
          font-weight: bold;
        }
      `}</style>
    </button>
  );
}

export default Button;
